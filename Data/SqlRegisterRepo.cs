using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlRegisterRepo : IRegisterRepo
    {
        private readonly CommanderContext _context;

        public SqlRegisterRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateRegister(Register register)
        {
            if(register == null) 
            {
                throw new ArgumentNullException(nameof(register));
            }
            _context.Registers.Add(register);
        }

        public void DeleteRegister(Register register)
        {
             if(register == null) 
            {
                throw new ArgumentNullException(nameof(register));
            }
            _context.Registers.Remove(register);
        }

        public IEnumerable<Register> GetAllRegisters()
        {
            return _context.Registers.ToList();
        }

        public Register GetRegisterById(int id)
        {
            return _context.Registers.FirstOrDefault(p => p.Id == id);
        }

        public Register GetRegisterByIdFirebase(string idFirebase)
        {
            return _context.Registers.FirstOrDefault(p => p.IdStudent == idFirebase);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateRegister(Register register)
        {
            //Nothing
        }
    }
}