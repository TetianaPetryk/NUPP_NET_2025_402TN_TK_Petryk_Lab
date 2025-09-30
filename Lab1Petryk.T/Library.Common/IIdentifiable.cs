using System;

namespace Library.Common
{
    public class Identifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
