using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace livecode.core
{
    public class JsonTransformator
    {
        public IEnumerable<IMapping> Mappings { get; }

        public JsonTransformator(IEnumerable<IMapping> mappings) { 
            Mappings = mappings;
        }


        public JObject TransformData(JObject jsonData)
        {
            var outputJObject = new JObject();

            foreach (var mapping in Mappings)
            {
                HandleMapping(jsonData, outputJObject, mapping.Input, mapping.Target);
            }

            return outputJObject;
        }

        private void HandleMapping(JObject jsonData, JObject outputJObject, string input, string target)
        {
            var token = jsonData.SelectToken(input);
            if (token != null)
            {
                outputJObject[target] = token.Value<string>();
            }
        }

        private void HandleMapping(JObject jsonData, JObject outputJObject, ConstInputFormat input, string target)
        {
            outputJObject[target] = input.Value;
        }

    }
}
