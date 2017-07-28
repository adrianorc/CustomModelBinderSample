using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.ModelBinders
{
    public class FrotaModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            //-- salva o objeto da request
            var request = bindingContext.HttpContext.Request;

            //-- lê o conteúdo postado e armazenda e post
            var post = "";
            using (var reader = new StreamReader(request.Body))
            {
                post = reader.ReadToEnd();
            }

            var frota = JsonConvert.DeserializeObject<Frota>(post, new FrotaJsonConverter());

            bindingContext.Result = ModelBindingResult.Success(frota);

            return Task.CompletedTask;
        }
    }
}
