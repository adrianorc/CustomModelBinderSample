using System;
using Newtonsoft.Json;
using WebApplication1.Models;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace WebApplication1.ModelBinders
{
    public class FrotaJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Frota).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);

            //-- salva o array que contem itens polimorficos
            var listaVeiculos = item["veiculos"];
            item.Remove("veiculos");

            //-- cria o objeto principal
            var frota = item.ToObject<Frota>();

            //-- converte cada um dos itens polimorficos da coleção
            foreach(var obj in listaVeiculos)
            {
                //-- aqui deve-se analisar que tipo de classe descendente criar
                if (obj["cor"] != null)
                {
                    //se o objeto possui cor, então é um carro
                    frota.Veiculos.Add(obj.ToObject<Carro>());
                }
                else
                {
                    frota.Veiculos.Add(obj.ToObject<Moto>());
                }
            }

            return frota;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
