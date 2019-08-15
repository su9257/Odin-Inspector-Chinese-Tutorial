//-----------------------------------------------------------------------
// <copyright file="AssetValidationProfile.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


namespace Sirenix.OdinValidator.Editor
{
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor.Validation;
    using Sirenix.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnityEditor;

    [Serializable]
    public class AssetValidationProfile : ValidationProfile
    {
        [FolderPath]
        public string[] SearchFilters = new string[] { "t:Prefab", "t:ScriptableObject" };

        [FolderPath]
        [PropertyTooltip("Add asset directoris or individual file paths.")]
        public string[] AssetPaths = new string[0];

        [Required]
        [PropertyTooltip("Add folders or files by reference.")]
        public UnityEngine.Object[] AssetReferences = new UnityEngine.Object[0];

        [FolderPath]
        [PropertyTooltip("Exclude asset directoris or individual file paths.")]
        public string[] ExcludeAssetPaths = new string[0];

        [Required]
        [PropertyTooltip("Exclude folders or files by reference.")]
        public UnityEngine.Object[] ExcludeAssetReferences = new UnityEngine.Object[0];

        public IEnumerable<string> GetAllAssetsToValidate()
        {
            if (this.AssetPaths == null) yield break;
            var allAssetPaths = this.AssetPaths.ToList();
            var allExcludeAssetPaths = this.ExcludeAssetPaths.ToList();
            foreach (var item in this.ExcludeAssetReferences.Where(x => x))
            {
                var path = AssetDatabase.GetAssetPath(item);
                if (!string.IsNullOrEmpty(path))
                {
                    if (Directory.Exists(path))
                    {
                        allAssetPaths.Add(path);
                    }
                    else if(File.Exists(path))
                    {
                        allExcludeAssetPaths.Add(path);
                    }
                }
            }

            var excludeMap = new HashSet<string>();

            // Exclude assets:
            var excludeDirectories = allExcludeAssetPaths.Select(x => x.Trim('/'))
                  .Where(x => !string.IsNullOrEmpty(x) && Directory.Exists(x))
                  .ToArray();

            var excludeAssetPaths = allExcludeAssetPaths.Where(x => File.Exists(x)).ToList();

            excludeMap.AddRange(excludeAssetPaths);
            if (excludeDirectories.Length > 0)
            {
                var guids = this.SearchFilters.SelectMany(x => AssetDatabase.FindAssets(x, excludeDirectories)).ToList();
                var assets = guids.Select(x => AssetDatabase.GUIDToAssetPath(x)).ToList();
                excludeMap.AddRange(assets);
            }

            // Add assets:
            var addDirectories = allAssetPaths.Select(x => x.Trim('/')).Where(x => !string.IsNullOrEmpty(x) && Directory.Exists(x)).ToArray();
            var addAssetPaths = allAssetPaths.Where(x => File.Exists(x)).ToList();

            if (addDirectories.Length > 0)
            {
                var guids = this.SearchFilters.SelectMany(x => AssetDatabase.FindAssets(x, addDirectories)).ToList();
                var assets = guids.Select(x => AssetDatabase.GUIDToAssetPath(x)).ToList();

                foreach (var asset in assets)
                {
                    if (excludeMap.Add(asset))
                    {
                        yield return asset;
                    }
                }
            }

            foreach (var asset in addAssetPaths)
            {
                if (excludeMap.Add(asset))
                {
                    yield return asset;
                }
            }
        }

        public override IEnumerable<ValidationProfileResult> Validate(ValidationRunner runner)
        {
            var assetPaths = this.GetAllAssetsToValidate().ToList();

            var step = 1f / assetPaths.Count;
            for (int i = 0; i < assetPaths.Count; i++)
            {
                var path = assetPaths[i];
                var progress = step * i;
                var assetsAtPath = AssetDatabase.LoadAllAssetsAtPath(path);

                foreach (var asset in assetsAtPath)
                {
                    List<ValidationResult> results = null;

                    runner.ValidateUnityObjectRecursively(asset, ref results);

                    yield return new ValidationProfileResult()
                    {
                        Profile = this,
                        Progress = progress,
                        Name = Path.GetFileName(path),
                        Source = asset,
                        Results = results,
                        SourceRecoveryData = asset,
                    };
                }
            }
        }
    }
}