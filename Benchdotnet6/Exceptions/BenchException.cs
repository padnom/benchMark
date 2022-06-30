using BenchmarkDotNet.Attributes;

using OneOf;

namespace Benchdotnet6.Exceptions
{
    public class BenchException
    {
        [Benchmark]
        public void GetPersonWithException()
        {
            try
            {
                PersonWithException();
            }
            catch (PersonException)
            {
                NothingToDo();
            }
        }

        [Benchmark]
        public void GetPersonWithOneOf()
        {
            OneOf<Person, InvalidPerson, InvalidPerson2, InvalidPerson3, InvalidPerson4, InvalidPerson5> person = PersonWithOneOf();
            person.Switch(
                person => NothingToPersonDo(),
                invalidPerson => NothingToDo(),
                invalidPerson => NothingToDo(),
                invalidPerson => NothingToDo(),
                invalidPerson => NothingToDo(),
                invalidPerson => NothingToDo()
                );
        }

        private void NothingToDo()
        {
        }

        private void NothingToPersonDo()
        {
        }

        private void PersonWithException()
        {
            NothingToDo();
        }

        private OneOf<Person, InvalidPerson, InvalidPerson2, InvalidPerson3, InvalidPerson4, InvalidPerson5> PersonWithOneOf()
        {
            return new InvalidPerson { Error = "error" };
        }
    }

    internal class InvalidPerson2
    {
    }

    internal class InvalidPerson3
    {
    }

    internal class InvalidPerson4
    {
    }

    internal class InvalidPerson5
    {
    }
}