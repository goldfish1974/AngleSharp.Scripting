﻿namespace AngleSharp.Scripting.CSharp.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    [TestFixture]
    public class ConversionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertCurrentDocumentOfFreshBrowsingContextWithoutDocumentShouldThrowException()
        {
            var context = BrowsingContext.New();
            var document = context.GetDynamicDocument();
            Assert.IsNotNull(document);
        }

        [Test]
        public async Task ConvertCurrentDocumentOfBrowsingContextShouldWork()
        {
            var url = "http://www.test.com/";
            var context = BrowsingContext.New();
            await context.OpenNewAsync(url);
            var document = context.GetDynamicDocument();
            Assert.IsNotNull(document);
        }

        [Test]
        public async Task ConvertDocumentShouldResultInRightUrl()
        {
            var url = "http://www.test.com/";
            var context = BrowsingContext.New();
            var original = await context.OpenNewAsync(url);
            var document = original.ToDynamic();
            Assert.IsNotNull(document);
            Assert.AreEqual(url, document.URL);
        }
    }
}
