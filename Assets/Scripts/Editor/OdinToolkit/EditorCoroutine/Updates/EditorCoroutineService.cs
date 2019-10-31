using System;
using System.Collections;
using System.Reflection;
using UnityEditor;

    /// <summary>
    /// Static service to help start EditorCoroutines.
    /// </summary>
    public static class EditorCoroutineService
    {
        private static readonly IUpdateService<EditorCoroutine> updateService;
        private static readonly ICoroutineFactory<EditorCoroutine> coroutineFactory;

        static EditorCoroutineService ()
        {
            updateService = new EditorCoroutineUpdate ();
            coroutineFactory = new EditorCoroutineFactory ();
        }

        
        [InitializeOnLoadMethod]//此特性允许在Unity加载时初始化编辑器类方法，而无需用户采取任何措施。
        private static void InitializeOnLoad()
        {
            EditorCoroutineUpdate editorUpdateService = (EditorCoroutineUpdate)updateService;
            editorUpdateService.PreviousTimeSinceStartup = EditorApplication.timeSinceStartup;
            EditorApplication.update -= editorUpdateService.OnUpdate;
            EditorApplication.update += editorUpdateService.OnUpdate;
        }

        public static EditorCoroutine StartCoroutine (IEnumerator routine)
        {
            EditorCoroutine coroutine = coroutineFactory.Create (null, routine);
            return updateService.StartCoroutine (coroutine);
        }

        public static EditorCoroutine StartCoroutine (object owner, string methodName, object[] methodArgs = null)
        {
            if (owner == null)
            {
                throw new ArgumentNullException (nameof(owner), "EditorCoroutine cannot be invoked by name from a null object.");
            }

            MethodInfo methodInfo = owner.GetType ().GetMethod (methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo == null)
            {
                throw new ArgumentException ($"Coroutine with name {methodName} does not exist on instance of type {owner.GetType ()}.", nameof(methodName));
            }

            if (methodInfo.ReturnType != typeof(IEnumerator))
            {
                throw new ArgumentException ($"Coroutine with name {methodName} does not return an IEnumerator.", nameof(methodName));
            }

            object returned = methodInfo.Invoke (owner, methodArgs);
            IEnumerator routine = returned as IEnumerator;
            EditorCoroutine coroutine = coroutineFactory.Create (owner, routine);
            return updateService.StartCoroutine (coroutine);
        }

        public static void StopCoroutine (IEnumerator routine)
        {
            string coroutineId = coroutineFactory.CreateId (null, routine);
            updateService.StopCoroutine (coroutineId);
        }


        public static void StopCoroutine (EditorCoroutine coroutine)
        {
            updateService.StopCoroutine (coroutine);
        }

        public static void StopCoroutine (object owner, string methodName)
        {
            string coroutineId = coroutineFactory.CreateId (owner, methodName);
            updateService.StopCoroutine (coroutineId);
        }


        public static void StopAllCoroutines ()
        {
            updateService.StopAllCoroutines ();
        }

        public static void StopAllCoroutines (object owner)
        {
            int ownerHash = coroutineFactory.GetOwnerHash (owner);
            updateService.StopAllCoroutines (ownerHash);
        }
    }

