using OnionArchitecture.Application.DTOs;
using System.Collections;

namespace OnionArchitecture.Tests.BlogTest
{
    public class BlogTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new BlogDto { Title= "Tech Blog", Content= "Latest tech trends.", Publisher="Publisher1"} };
            yield return new object[] { new BlogDto { Title = "Health Blog", Content = "Tips for healthy living.", Publisher = "Publisher1" } };
            yield return new object[] { new BlogDto { Title = "Travel Blog", Content = "Best places to visit in 2025.", Publisher = "Publisher1" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
