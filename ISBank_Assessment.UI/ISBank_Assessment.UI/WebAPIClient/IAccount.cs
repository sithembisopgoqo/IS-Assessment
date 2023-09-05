﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Account operations.
    /// </summary>
    public partial interface IAccount
    {
        /// <summary>
        /// Returns a list of all available AccountEntity for the specified
        /// User
        /// </summary>
        /// <param name='personCode'>
        /// </param>
        /// <param name='searchText'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<AccountEntity>>> GetAllAccountsWithHttpMessagesAsync(int personCode, string searchText = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns a list of all available AccountEntity for the specified
        /// User
        /// </summary>
        /// <param name='code'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<AccountEntity>> GetAccountsWithHttpMessagesAsync(int code, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns a single AccountEntity for the specified Person
        /// </summary>
        /// <param name='code'>
        /// Code of the Person to retrieve results for
        /// </param>
        /// <param name='personCode'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<AccountEntity>> GetAccountByPersonCodeWithHttpMessagesAsync(int code, int personCode, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add a AccountEntity object
        /// </summary>
        /// <param name='accountObj'>
        /// AccountEntity object to add
        /// </param>
        /// <param name='userId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<AccountEntity>> AddAccountWithHttpMessagesAsync(AccountEntity accountObj, int userId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Modify a AccountEntity object
        /// </summary>
        /// <param name='accountObj'>
        /// AccountEntity object to modify
        /// </param>
        /// <param name='code'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<AccountEntity>> ModifyAccountWithHttpMessagesAsync(AccountEntity accountObj, int code, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <param name='code'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> RemoveAccountWithHttpMessagesAsync(int code, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Change Account Status by Code and Status Id
        /// </summary>
        /// <param name='code'>
        /// </param>
        /// <param name='statusId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> ChangeAccountStatusWithHttpMessagesAsync(int code, int statusId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Check Person Account Status
        /// </summary>
        /// <param name='accountNumber'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<bool?>> CheckPersonAccounttStatusWithHttpMessagesAsync(string accountNumber, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Check If Account Is Open/Closed
        /// </summary>
        /// <param name='accountNumber'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<bool?>> CheckIfAccountIsOpenClosedWithHttpMessagesAsync(string accountNumber, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Check if Account Balance is greater then 0
        /// </summary>
        /// <param name='accountNumber'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<bool?>> CheckAccountBalanceWithHttpMessagesAsync(string accountNumber, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns a list of all available TransactionsEntity for the
        /// specified Acccount
        /// </summary>
        /// <param name='accountCode'>
        /// </param>
        /// <param name='searchText'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<TransactionsEntity>>> GetAllTransactionsWithHttpMessagesAsync(int accountCode, string searchText = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns a single TransactionsEntity for the specified Acccount
        /// </summary>
        /// <param name='code'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransactionsEntity>> GetTransactionbyCodeWithHttpMessagesAsync(int code, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add a TransactionsEntity object
        /// </summary>
        /// <param name='transactionObj'>
        /// TransactionsEntity object to add
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransactionsEntity>> AddTransactionWithHttpMessagesAsync(TransactionsEntity transactionObj, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Modify a TransactionsEntity object
        /// </summary>
        /// <param name='accountObj'>
        /// TransactionsEntity object to modify
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransactionsEntity>> ModifyTransactionWithHttpMessagesAsync(TransactionsEntity accountObj, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Checks if the Transaction Amount Value is 0
        /// </summary>
        /// <param name='amount'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<bool?>> CheckTransactionAmountValueWithHttpMessagesAsync(double amount, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns a single StatusEntity
        /// </summary>
        /// <param name='statusId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<StatusEntity>>> GetStatusByIdWithHttpMessagesAsync(int statusId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
