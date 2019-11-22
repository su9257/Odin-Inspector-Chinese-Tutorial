using Sirenix.OdinInspector.Editor.Validation;
[assembly: RegisterValidator(typeof(CustomTypeValidator))]

public class CustomTypeValidator : ValueValidator<TestCustomComponent.CustomType>
{
    protected override void Validate(TestCustomComponent.CustomType value, ValidationResult result)
    {
        if (value== TestCustomComponent.CustomType.Node)
        {
            result.ResultType = ValidationResultType.Warning;
            result.Message = "需要对CustomType使用除None以外的任何值";
        }
    }
}