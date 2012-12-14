﻿namespace NServiceBus.Core.Tests.Fakes
{
    using System;
    using Unicast.Transport;

    public class FakeTransport : ITransport
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        public void Start(string inputqueue)
        {
            Start(Address.Parse(inputqueue));
        }

        public bool IsStarted { get; set; }
        public Address InputAddress { get; set; }
        public void Start(Address localAddress)
        {
            IsStarted = true;
            InputAddress = localAddress;
        }

        public int HasChangedMaximumConcurrencyLevelNTimes { get; set; }

        public int MaximumConcurrencyLevel { get; private set; }

        public void ChangeNumberOfWorkerThreads(int targetNumberOfWorkerThreads)
        {
            ChangeMaximumConcurrencyLevel(targetNumberOfWorkerThreads);
        }

        public void ChangeMaximumConcurrencyLevel(int maximumConcurrencyLevel)
        {
            MaximumConcurrencyLevel = maximumConcurrencyLevel;
            HasChangedMaximumConcurrencyLevelNTimes++;
        }

        public void AbortHandlingCurrentMessage()
        {
            throw new NotImplementedException();
        }

        public int NumberOfWorkerThreads { get; set; }

        public int MaxThroughputPerSecond { get; set; }

        public int MaximumThroughputPerSecond { get; private set; }

        public bool IsEventAssiged
        {
            get { return TransportMessageReceived != null; }
        }

        public void RaiseEvent(TransportMessage message)
        {
            TransportMessageReceived(this, new TransportMessageReceivedEventArgs(message));
        }

        public void ChangeMaximumThroughputPerSecond(int maximumThroughputPerSecond)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<TransportMessageReceivedEventArgs> TransportMessageReceived;
        public event EventHandler<StartedMessageProcessingEventArgs> StartedMessageProcessing;
        public event EventHandler FinishedMessageProcessing;
        public event EventHandler<FailedMessageProcessingEventArgs> FailedMessageProcessing;
    }
}