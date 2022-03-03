# Input or Output

The Result type is considered a `Discriminated Union`. All this means is that it can be one of two types, but never both at once.

Here's an example of using a Result type for an Http call.

```csharp

public async Task<IResult<Customer, Error>> Read(Guid customerId)
{
    using var response = await _httpClient.GetAsync($"https://api-test/api/1/customers/{customerId}");
    using var contentStream = await response.Content.ReadAsStreamAsync();
    var customerResult = await JsonDeserializer.Deserialize<ApiCustomerResult>(contentStream, _jsonOptions);
    return (customerResult switch
    {
        { HasErrors: true } => Error<Customer, Error>(new Error(customerResult.Message)),
        _ => Ok<Customer, Error>(customerResult.ToCustomer())
    }).AsTask();
}
```
