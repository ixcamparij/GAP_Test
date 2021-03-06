﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Data.Models;
using NHibernate;
using NHibernate.Linq;

namespace Domain_Data
{
    public class DataBaseConnector : IDataBaseConnector
    {
        #region User

        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                user = await session.GetAsync<User>(id);
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            IEnumerable<User> users = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                users = await session.Query<User>().ToListAsync();
            }

            return users;
        }

        #endregion

        #region Customer
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                customer = await session.GetAsync<Customer>(id);
            }

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            IEnumerable<Customer> customer = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                customer = await session.Query<Customer>().ToListAsync();
            }

            return customer;
        }
        #endregion

        #region Policy
        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            Policy policy = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policy = await session.GetAsync<Policy>(id);
            }

            return policy;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            IEnumerable<Policy> policies = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policies = await session.Query<Policy>().ToListAsync();
            }

            return policies;
        }

        public async Task<IEnumerable<Assign>> GetAssignedPoliciesAsync()
        {
            IEnumerable<Assign> policies = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policies = await session.Query<Assign>().ToListAsync();
            }

            return policies;
        }

        public async Task CreatePolicyAsync(Policy policy)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction()) 
                {
                    await session.SaveAsync(policy); 
                    await transaction.CommitAsync(); 
                }
            }
        }

        public async Task UpdatePolicyAsync(Policy policy)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.SaveOrUpdateAsync(policy);
                    await transaction.CommitAsync();
                }
            }
        }

        public async Task DeletePolicyAsync(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Policy policy = await this.GetPolicyByIdAsync(id);

                using (ITransaction trans = session.BeginTransaction())
                {
                    await session.DeleteAsync(policy);
                    await trans.CommitAsync();
                }
            }
        }

        public async Task<Assign> GetAssignedPolicyByIdAsync(int id)
        {
            Assign policy = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policy = await session.GetAsync<Assign>(id);
            }

            return policy;
        }

        public async Task CreateAssignedPoliciesAsync(Assign policy)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.SaveAsync(policy);
                    await transaction.CommitAsync();
                }
            }
        }

        public async Task DeleteAssignedPolicyAsync(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Assign policy = await this.GetAssignedPolicyByIdAsync(id);

                using (ITransaction trans = session.BeginTransaction())
                {
                    await session.DeleteAsync(policy);
                    await trans.CommitAsync();
                }
            }
        }

        #endregion
    }
}
