using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class User : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        private HashSet<Order> orders;
        public IEnumerable<Order> Orders => orders?.ToList();
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
        public string IP { get; private set; }
        public Role Role { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

		private User() { }

		public void SetPassword(byte[] passwordHash, byte[] passwordSalt) {
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
		}
    }
}
