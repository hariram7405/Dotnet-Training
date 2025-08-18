// BUGGY CODE DEBUGGING CHALLENGE - FIXED VERSION

// Original buggy code:
/*
public async Task TransferMoney(string fromAcc, string toAcc, decimal amount)
{
    var sender = _accountRepo.GetByAccountNumber(fromAcc);
    var receiver = _accountRepo.GetByAccountNumber(toAcc);

    if(sender.Balance < amount)
        throw new Exception("Insufficient funds");

    sender.Balance -= amount;
    receiver.Balance += amount;
}
*/

// FIXED VERSION:
public async Task TransferMoney(string fromAcc, string toAcc, decimal amount)
{
    // Fix 1: Use async methods properly with await
    var sender = await _accountRepo.GetByAccountNumberAsync(fromAcc);
    var receiver = await _accountRepo.GetByAccountNumberAsync(toAcc);

    // Fix 2: Add null checks to prevent NullReferenceException
    if (sender == null)
        throw new ArgumentException("Sender account not found");
    if (receiver == null)
        throw new ArgumentException("Receiver account not found");

    // Fix 3: Add validation for amount
    if (amount <= 0)
        throw new ArgumentException("Amount must be positive");

    // Fix 4: Check account status
    if (!sender.IsActive)
        throw new InvalidOperationException("Sender account is inactive");
    if (!receiver.IsActive)
        throw new InvalidOperationException("Receiver account is inactive");

    // Fix 5: Use proper exception type for business logic
    if (sender.Balance < amount)
        throw new InvalidOperationException("Insufficient funds");

    // Fix 6: For concurrency, we could use locks or atomic operations
    // In a real scenario, we'd use database transactions or optimistic concurrency
    lock (_lockObject) // Assuming _lockObject is a private readonly object
    {
        sender.Balance -= amount;
        receiver.Balance += amount;
    }

    // Fix 7: Persist changes using async methods
    await _accountRepo.UpdateAsync(sender);
    await _accountRepo.UpdateAsync(receiver);
}

/*
FIXES EXPLAINED:
1. Async Usage: Changed synchronous calls to async/await pattern
2. Null Checks: Added validation to prevent null reference exceptions
3. Input Validation: Added check for positive amount
4. Account Status: Verify accounts are active before transfer
5. Exception Types: Use appropriate exception types for different scenarios
6. Concurrency: Added lock for thread safety (basic approach)
7. Data Persistence: Ensure changes are saved using async update methods
*/