using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace WebApplication1.ModelBinders
{
    public class FrotaModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Frota))
            {
                return new FrotaModelBinder();
            }

            return null;
        }
    }
}
