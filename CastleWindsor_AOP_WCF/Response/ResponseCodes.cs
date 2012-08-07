namespace CastleWindsor_AOP_WCF.Response
{
    public enum ResponseCodes
    {
        Success = 000,
        SystemError = 001,
        DbError = 002,
        NoPermissionFound = 003,
        NoRecordFound = 004,
        WorkflowError = 006,
        ServiceError = 007,
        IncorrectLoginCredentials = 008,
        EmailAddressDefinedAlready = 009,
        Authorized = 010,
        NotAuthorized = 011,
        AlreadyDefined = 012,
        MissingData = 013,
        ProvisionAlreadyTaken = 014,
        TicketAlreadyTaken = 015,
        ProvisionNotFound = 016,
        SomeDataNotUpdated = 017,
        ProvisionExpired = 018,
        TransactionAlreadyCancelled = 019,
        InquiryError = 020,
        PaymentError = 021,
        RefundError = 022,
        VoidError = 023,
        NotImplemented = 024
    }
}