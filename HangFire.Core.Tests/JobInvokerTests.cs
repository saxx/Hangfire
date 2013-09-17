﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using ServiceStack.Text;

namespace HangFire.Tests
{
    [TestClass]
    public class JobInvokerTests
    {
        /*private ServerJobInvoker _jobInvoker;
        private Mock<IEnumerable<IServerJobFilter>> _filtersMock;

        [TestInitialize]
        public void SetUp()
        {
            _filtersMock = new Mock<IEnumerable<IServerJobFilter>>();
            _filtersMock.Setup(x => x.GetEnumerator()).Returns(Enumerable.Empty<IServerJobFilter>().GetEnumerator);

            _jobInvoker = new JobInvoker( _filtersMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ThrowsException_WhenNullFiltersCollectionWasProvided()
        {
            // ReSharper disable once UnusedVariable
            var invoker = new JobInvoker(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Invoke_ThrowsArgumentNullException_WhenNullJobInstanceWasProvided()
        {
            _jobInvoker.InvokeJob(null, new Dictionary<string, string>());
        }

        [TestMethod]
        public void Invoke_InvokesTheJob_WhenItIsCorrect()
        {
            var testJob = new CorrectJob();
            _jobInvoker.InvokeJob(testJob, new Dictionary<string, string>());

            Assert.IsTrue(testJob.Performed);
        }*/

        /*[TestMethod]
        [ExpectedException(typeof(JobActivationException))]
        public void Invoke_ThrowsActivationException_WhenJobClassCanNotBeFound()
        {
            var jobDescription = new JobDescription(typeof(PerformlessJob), null);
            jobDescription.JobType = "HelloWorld";
            _jobInvoker.InvokeJob(jobDescription);
        }*/

        /*[TestMethod]
        [ExpectedException(typeof(JobActivationException))]
        public void Invoke_ThrowsActivationException_WhenJobActivatorThrowsAnyException()
        {
            _jobActivatorMock.Setup(x => x.ActivateJob(It.IsAny<Type>())).Throws<MissingMethodException>();
            var jobDescription = new JobDescription(typeof(PerformlessJob), null);
            _jobInvoker.InvokeJob(jobDescription);
        }*/

        /*[TestMethod]
        public void Invoke_CorrectlyDeserializesJobParameters()
        {
            var job = new ArgumentsJob();
            _jobActivatorMock.Setup(x => x.ActivateJob(It.IsAny<Type>())).Returns(job);

            var jobDescription = new JobDescription(typeof(ArgumentsJob), new { a = 3, b = "5" });
            _jobInvoker.InvokeJob(jobDescription);

            Assert.AreEqual(3, job.A);
            Assert.AreEqual("5", job.B);
        }*/

        /*[TestMethod]
        public void Invoke_UsesDefaultValuesOfArguments_WhenNoValueWasProvided()
        {
            var job = new ArgumentsJob();
            _jobActivatorMock.Setup(x => x.ActivateJob(It.IsAny<Type>())).Returns(job);

            var jobDescription = new JobDescription(typeof(ArgumentsJob), new { a = 5 });
            _jobInvoker.InvokeJob(jobDescription);

            Assert.AreEqual(5, job.A);
            Assert.AreEqual("10", job.B);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invoke_ThrowsException_WhenNoValueWasProvided()
        {
            var jobDescription = new JobDescription(typeof(ArgumentsJob), new { b = "4" });
            _jobInvoker.InvokeJob(jobDescription);
        }

        [TestMethod]
        public void Invoke_IgnoresRedundantArguments()
        {
            var jobDescription = new JobDescription(typeof(ArgumentsJob), new { a = 1, b = "2", c = 3 });
            _jobInvoker.InvokeJob(jobDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Invoke_ThrowsException_WhenTheValueCanNotBeConvertedToArgumentType()
        {
            var jobDescription = new JobDescription(typeof(ArgumentsJob), new { a = DateTime.UtcNow });
            _jobInvoker.InvokeJob(jobDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Invoke_ThrowsSourceException_WhenJobHasRaisedOne()
        {
            var jobMock = new Mock<CorrectJob>();
            jobMock.Setup(x => x.Perform()).Throws<InvalidOperationException>();
            _jobActivatorMock.Setup(x => x.ActivateJob(It.IsAny<Type>())).Returns(jobMock.Object);

            var jobDescription = new JobDescription(typeof(CorrectJob), null);
            _jobInvoker.InvokeJob(jobDescription);
        }

        [TestMethod]
        public void Invoke_DisposesTheJob_WhenIDisposedIsImplemented()
        {
            var job = new DisposableJob();
            _jobActivatorMock.Setup(x => x.ActivateJob(It.IsAny<Type>())).Returns(job);

            var jobDescription = new JobDescription(typeof(DisposableJob), null);
            _jobInvoker.InvokeJob(jobDescription);

            Assert.AreEqual(true, job.Disposed);
        }

        [TestMethod]
        public void Invoke_InvokesFiltersWithCorrectArguments_WhenTheyArePresent()
        {
            var filter = new Mock<IServerFilter>();
            var filters = new List<IServerFilter> { filter.Object };

            _filtersMock.Setup(x => x.GetEnumerator()).Returns(() => filters.GetEnumerator());

            var jobDescription = new JobDescription(typeof(CorrectJob), null);
            _jobInvoker.InvokeJob(jobDescription);
            
            filter.Verify(x => x.ServerFilter(
                It.Is<ServerFilterContext>(y => y.JobDescription == jobDescription && y.Job != null && y.PerformAction != null)),
                Times.Once);
        }

        [TestMethod]
        public void Invoke_InvokesFiltersWithReversedOrder()
        {
            var lastFilter = String.Empty;

            var filterOuter = new Mock<IServerFilter>();
            filterOuter.Setup(x => x.ServerFilter(It.IsAny<ServerFilterContext>())).Callback(() => lastFilter = "Outer");

            var filterInner = new Mock<IServerFilter>();
            filterInner.Setup(x => x.ServerFilter(It.IsAny<ServerFilterContext>())).Callback(() => lastFilter = "Inner");

            var filters = new List<IServerFilter> { filterOuter.Object, filterInner.Object };
            _filtersMock.Setup(x => x.GetEnumerator()).Returns(() => filters.GetEnumerator());

            var jobDescription = new JobDescription(typeof(CorrectJob), null);
            _jobInvoker.InvokeJob(jobDescription);

            Assert.AreEqual("Outer", lastFilter);
        }
         * */

        public class CorrectJob : BackgroundJob
        {
            public bool Performed { get; set; }

            public override void Perform()
            {
                Performed = true;
            }
        }

        public class ArgumentsJob
        {
            public int A { get; set; }
            public string B { get; set; }

            public void Perform(int a, string b = "10")
            {
                A = a;
                B = b;
            }
        }

        public class DisposableJob : IDisposable
        {
            public bool Disposed { get; set; }

            public void Perform()
            {
            }

            public void Dispose()
            {
                Disposed = true;
            }
        }
    }
}
