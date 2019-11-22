using Sirenix.OdinInspector.Editor.Validation;
using System;
using System.Reflection;

[assembly: RegisterValidator(typeof(CustomeAttributeValidator))]
public class TestValidatorAttribute : Attribute { }

/// <summary>
/// 对此自定义特性的检测机制
/// </summary>

public class CustomeAttributeValidator : AttributeValidator<TestValidatorAttribute, TestCustomComponent.CustomType>
{
    protected override void Validate(object parentInstance, TestCustomComponent.CustomType memberValue, MemberInfo member, ValidationResult result)
    {
        try
        {
            //Debug.Log($"parentInstance:{parentInstance}---memberValue:{memberValue}---member:{member}---result:{result}");
            if (memberValue == TestCustomComponent.CustomType.One)
            {
                throw new ArgumentException($"不能使用{memberValue}");
            }
        }
        catch (ArgumentException ex)
        {
            result.ResultType = ValidationResultType.Error;
            result.Message = "错误或无效的CustomType值: " + ex.Message;
        }
    }
}
