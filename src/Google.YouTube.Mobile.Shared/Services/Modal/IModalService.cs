﻿using System.Threading.Tasks;
using Google.YouTube.Views;
using Xamarin.Forms;

namespace Google.YouTube.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}