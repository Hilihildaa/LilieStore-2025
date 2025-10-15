using Core.Entities;

namespace Core.Specifications;


public class TypeListSpecification : BaseSpecification<Product, string>
{
    public TypeListSpecification()
    {
        AddSelector(x => x.Type);
        ApplyDistinct();
    }

}