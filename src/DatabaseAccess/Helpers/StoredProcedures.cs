namespace DatabaseAccess.Helpers
{
    public static class StoredProcedures
    {
        public static string SpBcParameterGet => "spBCParameter_Get";
        public static string SpBcParameterGetAll => "spBCParameter_GetAll";
        public static string SpBcParameterInsert => "spBCParameter_Insert";
        public static string SpBcParameterUpdate => "spBCParameter_Update";
        public static string SpOnlineEventGet => "spOnlineEvent_Get";
        public static string SpOnlineEventGetAll => "spOnlineEvent_GetAll";
        public static string SpOnlineEventInsert => "spOnlineEvent_Insert";
        public static string SpOnlineEventUpdate => "spOnlineEvent_Update";
        public static string SpStreamGet => "spStream_Get";
        public static string SpStreamGetAll => "spStream_GetAll";
        public static string SpStreamInsert => "spStream_Insert";
        public static string SpStreamUpdate => "spStream_Update";
        public static string SpCloseOldStreams => "spCloseOldStreams";
        public static string SpEmailTemplatesGet => "spEmailTemplates_Get";
    }
}
