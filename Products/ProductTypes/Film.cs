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
        private string? _director;
        private string? _writer;
        private string? _producer;
        private string? _cinematography;
        private string? _editor;
        private string? _composer;
        private string? _productionCompany;
        private string? _distributor;
        private DateTime? _releaseDate;
        private int? _runningTime; // Running time in minutes.
        private string? _country;
        private string? _language;

        public Film(string title, ProductState state, string? director, string? writer, string? producer, string? cinematography, string? editor, string? composer, string? productionCompany, string? distributor, DateTime? releaseDate, int? runningTime, string? country, string? language)
        {
            this.Title = title;
            this._director = director;
            this._writer = writer;
            this._producer = producer;
            this._cinematography = cinematography;
            this._editor = editor;
            this._composer = composer;
            this._productionCompany = productionCompany;
            this._distributor = distributor;
            this._releaseDate = releaseDate;
            this._runningTime = runningTime;
            this._country = country;
            this._language = language;

            this.TransitionTo(state);
        }

        public override void PrintDetails()
        {
            throw new NotImplementedException();
        }
    }
}
