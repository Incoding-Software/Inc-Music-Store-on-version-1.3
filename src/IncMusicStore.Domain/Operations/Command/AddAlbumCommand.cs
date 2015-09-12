namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Incoding.CQRS;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class AddAlbumCommand : CommandBase
    {
        public override void Execute()
        {
            var artist = Repository.GetById<Artist>(ArtistId);
            var genre = Repository.GetById<Genre>(GenreId);

            Repository.Save(new Album(Title, artist, genre, Price, ArtUrl));
        }

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public class Validator : AbstractValidator<AddAlbumCommand>
        {
            public Validator()
            {
                RuleFor(r => r.Title).NotEmpty();
                RuleFor(r => r.Price).NotEmpty();
                RuleFor(r => r.ArtUrl).NotEmpty();
                RuleFor(r => r.ArtistId).NotEmpty();
                RuleFor(r => r.GenreId).NotEmpty();
            }
        }

        #region Properties

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ArtUrl { get; set; }

        public string ArtistId { get; set; }

        public string GenreId { get; set; }

        #endregion
    }
}