﻿namespace IncMusicStore.Domain
{
    using System;
    using Incoding.Data;

    public class AlbumWithGenreFetchSpec : FetchSpecification<Album>
    {
        public override Action<AdHocFetchSpecificationBase<Album>> FetchedBy()
        {
            return specification => specification.Join(r => r.Genre);
        }
    }
}