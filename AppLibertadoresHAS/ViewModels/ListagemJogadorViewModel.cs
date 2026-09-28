using AppLibertadoresHAS.Models;
using AppLibertadoresHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.ViewModels
{
    public class ListagemJogadorViewModel : BaseViewModel
    {
        private readonly JogadorService _jogadorService;
        public ObservableCollection<Jogador> Jogadores { get; set; }
        public ListagemJogadorViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            _jogadorService = new JogadorService(token);
            Jogadores = new ObservableCollection<Jogador>();

            - = CarregarJogadores();

        }

      private async void CarregarJogadores()
        {
            Jogadores = await _jogadorService.GetJogadoresAsync();

            OnPropertyChanged(nameof(Jogadores));
        }



    }
}
