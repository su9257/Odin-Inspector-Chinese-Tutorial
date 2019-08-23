using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Sirenix.OdinInspector.Editor.Validation;

[assembly: RegisterValidator(typeof(RegexValidator))]
public class RegexAttribute : Attribute { }

public class RegexValidator : AttributeValidator<RegexAttribute, string>
{
    protected override void Validate(object parentInstance, string memberValue, MemberInfo member, ValidationResult result)
    {
        try
        {
            Regex.Match("", memberValue);
        }
        catch (ArgumentException ex)
        {
            result.ResultType = ValidationResultType.Error;
            result.Message = "无效的正则表达式的字符串: " + ex.Message;
        }
    }
}