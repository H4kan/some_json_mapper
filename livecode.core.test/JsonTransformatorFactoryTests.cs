namespace livecode.core.test
{
    [TestClass]
    public class JsonTransformatorFactoryTests
    {

        public JsonTransformatorFactoryTests() {

        }

        [TestMethod]
        public void JsonTransformatorFactory_Should_ParseSimpleScenario()
        {

            var jsonTransformatorFactory = new JsonTransformatorFactory();

            var jsonMap = File.ReadAllText("../../../data/maps/transformator_map_test1.json");

            var parserMappings = jsonTransformatorFactory.GenerateParser(jsonMap)
                .Mappings.OrderBy(m => m.Input).ToList();

            

            var mappings = new List<IMapping>()
            {
                new BaseMapping(){ Input = "firstname", Target = "lastname" },
                new BaseMapping(){ Input = "lastname", Target = "firstname" }
            };

            for (int i = 0; i  < mappings.Count; i++)
            {
                Assert.AreEqual(parserMappings[i].Input, mappings[i].Input);
                Assert.AreEqual(parserMappings[i].Target, mappings[i].Target);
            }

        }


        [TestMethod]
        public void JsonTransformatorFactory_Should_ParseWithConstType()
        {

            var jsonTransformatorFactory = new JsonTransformatorFactory();

            var jsonMap = File.ReadAllText("../../../data/maps/transformator_map_test2.json");

            var parserMappings = jsonTransformatorFactory.GenerateParser(jsonMap)
                .Mappings.ToList();



            var mappings = new List<IMapping>()
            {
                new BaseMapping(){ Input = "firstname", Target = "lastname" },
                new BaseMapping(){ Input = new ConstInputFormat()
                {
                    Type = "const",
                    Value = "123"
                }, Target = "firstname" }
            };

            Assert.AreEqual(parserMappings[0].Input, mappings[0].Input);
            Assert.AreEqual(parserMappings[0].Target, mappings[0].Target);

            Assert.AreEqual((parserMappings[1].Input as ConstInputFormat)!.Type,
                (mappings[1].Input as ConstInputFormat)!.Type);
            Assert.AreEqual((parserMappings[1].Input as ConstInputFormat)!.Value,
              (mappings[1].Input as ConstInputFormat)!.Value);
            Assert.AreEqual(parserMappings[1].Target, mappings[1].Target);

        }
    }
}