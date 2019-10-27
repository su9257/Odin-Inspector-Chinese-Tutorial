//using Sirenix.OdinInspector.Editor.Validation;
//using Sirenix.OdinValidator.Editor;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//[CreateAssetMenu]
//public class MyDatabaseValidatorAsset : ValidationProfileAsset<MyDatabaseValidator>
//{
//}

//[Serializable]
//public class MyDatabaseValidator : IValidationProfile
//{
//    public string Name;
//    public string Description;
//    public string DatabaseFilePath;

//    string IValidationProfile.Name { get => this.Name; set => this.Name = value; }
//    string IValidationProfile.Description { get => this.Description; set => this.Description = value; }
//    Texture IValidationProfile.GetProfileIcon() => Sirenix.Utilities.Editor.EditorIcons.FileCabinet.Active;
//    object IValidationProfile.GetSource(ValidationProfileResult entry) => entry.Source;
//    IEnumerable<IValidationProfile> IValidationProfile.GetNestedValidationProfiles() { yield break; }

//    public IEnumerable<ValidationProfileResult> Validate(ValidationRunner runner)
//    {
//        var imaginaryDatabase = new ImaginaryDatabase();
//        var items = imaginaryDatabase.GetAndDeserializeAllImaginaryItems();

//        for (int i = 0; i < items.Length; i++)
//        {
//            var item = items[i];

//            var results = new ValidationProfileResult();
//            results.Name = item.Name;
//            results.Profile = this;
//            results.Progress = (float)i / items.Length;
//            results.Source = item;
//            results.Results = new List<ValidationResult>();

//            // Calling ValidateValue will use all defined Validators, and populate the results with errors and warnings.
//            // You can also manually add your own custom ValidationResult here, but it's better to write a 
//            // CustomValidator instead, so that Odin Inspector can pick them up and show them to you in the editor.
//            runner.ValidateValue(item, null, ref results.Results);

//            yield return results;
//        }
//    }
//}