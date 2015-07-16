﻿using System;
using System.Threading;
using Hangfire.Server;
using Moq;

namespace Hangfire.Core.Tests
{
    public class BackgroundProcessContextMock
    {
        private readonly Lazy<BackgroundProcessContext> _context;

        public BackgroundProcessContextMock()
        {
            ServerId = "server";
            Storage = new Mock<JobStorage>();
            CancellationTokenSource = new CancellationTokenSource();

            _context = new Lazy<BackgroundProcessContext>(
                () => new BackgroundProcessContext(ServerId, Storage.Object, CancellationTokenSource.Token));
        }

        public BackgroundProcessContext Object { get { return _context.Value; } }

        public string ServerId { get; set; }
        public Mock<JobStorage> Storage { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
    }
}