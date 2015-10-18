namespace CinemaSystem.Importer
{
    using System;
    using System.IO;
    using CinemaSystem.Data;

    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<CinameEntities, TextWriter> Get { get; }
    }
}
