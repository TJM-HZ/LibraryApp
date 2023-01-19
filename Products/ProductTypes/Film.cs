using LibraryApp.Products.ProductFSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductTypes
{
    class Film : Product
    {
        private string? director;
        private string? writer;
        private string? producer;
        private string? cinematography;
        private string? editor;
        private string? composer;
        private string? productionCompany;
        private string? distributor;
        private DateTime? releaseDate;
        private int? runningTime; // Running time in minutes.
        private string? country;
        private string? language;

        public Film(string title, ProductState state, string? director, string? writer, string? producer, string? cinematography, string? editor, string? composer, string? productionCompany, string? distributor, DateTime? releaseDate, int? runningTime, string? country, string? language)
        {
            this.Title = title;
            this.director = director;
            this.writer = writer;
            this.producer = producer;
            this.cinematography = cinematography;
            this.editor = editor;
            this.composer = composer;
            this.productionCompany = productionCompany;
            this.distributor = distributor;
            this.releaseDate = releaseDate;
            this.runningTime = runningTime;
            this.country = country;
            this.language = language;

            this.transitionTo(state);
        }
    }
}
