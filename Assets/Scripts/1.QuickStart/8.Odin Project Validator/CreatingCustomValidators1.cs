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
            UnityEngine.Debug.Log(parentInstance);
            UnityEngine.Debug.Log(memberValue);
            UnityEngine.Debug.Log(member);
            UnityEngine.Debug.Log(result);
            //Regex.Match("", memberValue);

           Match match = Regex.Match(memberValue, "菜鸟海澜");
            while (match.Success)
            {
                UnityEngine.Debug.Log($"匹配结果为{match.Value},对应的索引为{match.Index}");
                match = match.NextMatch();
            }
            if (!match.Success)
            {
                throw new ArgumentException("测试异常");
            }
        }
        catch (ArgumentException ex)
        {
            result.ResultType = ValidationResultType.Error;
            result.Message = "无效的正则表达式的字符串: " + ex.Message;
        }
        //result.ResultType = ValidationResultType.Error;
        //result.Message = "无效的正则表达式的字符串: ";
    }
}