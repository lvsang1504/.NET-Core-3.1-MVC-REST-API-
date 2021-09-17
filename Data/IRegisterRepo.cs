using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    public interface IRegisterRepo
    {
        bool SaveChanges();
        IEnumerable<Register> GetAllRegisters();

        Register GetRegisterById(int id);
        Register GetRegisterByIdFirebase(string IdStudent);
        void CreateRegister(Register register);
        void UpdateRegister(Register register);
        void DeleteRegister(Register register);
    }
}