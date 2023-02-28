using DiffEngine;

namespace John.Verif
{
    [UsesVerify]
    public class SnapshotTest
    {
        private readonly VerifySettings _verifySettings = new();

        public SnapshotTest()
        {
            _verifySettings.IgnoreMember<Person>(x => x.Id);
        }

        [Fact]
        public async Task GetById()
        {
            var id = "1";
            var person = new PeopleRepository().GetById(id);
            
            await Verify(person, _verifySettings);
        }
    }

    public class PeopleRepository
    {
        public Person GetById(string id)
        {
            return new() { Id = "2", Name = "John" };
        }
    }

    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}