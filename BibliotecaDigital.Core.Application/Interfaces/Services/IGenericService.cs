﻿namespace BibliotecaDigital.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
           where SaveViewModel : class
           where ViewModel : class
           where Entity : class
    {
        Task<SaveViewModel> Add(SaveViewModel vm);
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task Update(SaveViewModel vm, int id);
        Task Delete(int id);
    }
}
