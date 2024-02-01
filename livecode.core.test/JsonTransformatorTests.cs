using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace livecode.core.test
{
    [TestClass]
    public class JsonTransformatorTests
    {

        public JsonTransformatorTests() {

        }

        [TestMethod]
        public void JsonTransformator_Should_ParseSimpleScenario()
        {


            var mappings = new List<IMapping>()
            {
                new BaseMapping(){ Input = "firstname", Target = "lastname" },
                new BaseMapping(){ Input = "lastname", Target = "firstname" }
            };

            var jsonTransformator = new JsonTransformator(mappings);


            var jsonData = File.ReadAllText("../../../data/jsons/transformator_input_test1.json");

            var outputData = File.ReadAllText("../../../data/jsons/transformator_output_test1.json");



            jsonTransformator.TransformData(JObject.Parse(jsonData))
                .Should().BeEquivalentTo(JObject.Parse(outputData));
            

        }

        [TestMethod]
        public void JsonTransformator_Should_ParseConstType()
        {


            var mappings = new List<IMapping>()
            {
                new BaseMapping(){ Input = "firstname", Target = "lastname" },
                  new BaseMapping(){ Input = new ConstInputFormat()
                {
                    Type = "const",
                    Value = "123"
                }, Target = "firstname" }
            };

            var jsonTransformator = new JsonTransformator(mappings);


            var jsonData = File.ReadAllText("../../../data/jsons/transformator_input_test2.json");

            var outputData = File.ReadAllText("../../../data/jsons/transformator_output_test2.json");



            jsonTransformator.TransformData(JObject.Parse(jsonData))
                .Should().BeEquivalentTo(JObject.Parse(outputData));


        }
    }
}