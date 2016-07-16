using System;

namespace DddVariants.Variant1
{
    public interface IHaveDomainId
    {
        int Id { get; }
    }

    public abstract class Command
    {
    }

    public abstract class Event : IHaveDomainId
    {
        public int Id { get; set; }
    }

    public abstract class CreationResponse
    {
    }

    public class CreationOk : CreationResponse
    {
        public CreationOk(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public override string ToString()
        {
            return $"Created with Id {Id}";
        }
    }

    public class CreationFailed : CreationResponse
    {
        public CreationFailed(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; }

        public override string ToString()
        {
            return $"Failed due to {Reason}";
        }
    }
}


