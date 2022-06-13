namespace Domain
{
    using System.Runtime.Serialization;

namespace PMPA.Model
{


        public enum ResourceType
        {
            report=1,
            dashboard=2,
            form=3,
            workflow=4
        }
    public enum BannerType
    {
        Select = 0,
        Notification = 1,
        Alert = 2,
        Promotion = 3
    }

    public enum DetailDisplayType
    {
        Select = 0,
        More = 1,
        Expand = 2,
        LearnMore = 3
    }

    public enum GroupType
    {
        Select = 0,
        AdHoc = 1,
        Fixed = 2
    }

    public enum ContentType
    {
        Select = 0,
        Article = 1,
        Event = 2,
        Announcement = 3
    }

    public enum FrameObjectType
    {
        Chart = 1,
        Grid = 2,
        Gauge = 3,
        CustomPanel = 4,
        Pivot = 5
    }

    public enum LayoutType : short
    {
        FullWindow = 1,
        HorizontalWindow = 2,
        VerticalWindow = 3,
        Versago = 5
    }

    public enum ActionType
    {
        Select = 0,
        Service = 1,
        Url = 2
    }

    public enum ActionTrigger
    {
        Select = 0,
        PrimaryAction = 1,
        ActionSuccess = 2,
        ActionFailure = 3
    }

    public enum DataType
    {
        Select = 0,
        Text = 1,
        Numbers = 2,
        Binary = 3,
        Date = 4
    }

    public enum ControlType
    {

        Select = 0,
        TextBox = 1,
        Email = 2,
        Tel = 3,
        Radio = 4,
        Checkbox = 5,
        Submit = 6,
        Button = 7,
        DropdownList = 8,
        Grid = 9,
        Find = 10,
        NumericTextBox = 11,
        DatePicker = 12,
        TimePicker = 13,
        List = 14,
        Label = 15,
        FileUpload = 16,
        Image = 17,
        ActionWithConfirmClear = 18,
        ActionWithClear = 19,
        MultiText1 = 20,
        MultiText2 = 21,
        MultiText3 = 22,
        ClearWithGetAction = 23,
        ActionWithClearGet = 24,
        Password = 25,
        SectionTitle = 26,
        FindAll = 27,
        Signature = 28

    }

    public enum Relation
    {
        Select = 0,
        LessThan = 1,
        GreaterThan = 2,
        Between = 3,
        EqualTo = 4
    }

    public enum DisplayType
    {
        Select = 0,
        Cell = 1,
        Text = 2,
        Icon = 3
    }

    public enum ItemType
    {
        RegularMenu = 1,
        QuickActionMenu = 2
    }

    public enum ObjectType
    {
        [EnumMember(Value = "Data View")] 
        Report = 1,
        [EnumMember(Value = "Dashboard")]
        Dashboard = 2,
        [EnumMember(Value = "Form")]
        Form = 3,
        Menu=4,
        CrystalReport = 5,
        RecordProcessing = 6,
        Calendar = 7
    }

    public enum ParameterDataType
    {
        Int = 1,
        Binary = 2,
        Boolean = 3,
        Char = 4,
        Datetime = 5,
        Decimal = 6,
        Float = 7,
        Image = 8,
        Money = 9,
        Nchar = 10,
        NText = 11,
        Numeric = 12,
        Nvarchar = 13,
        Real = 14,
        SqlVariant = 15,
        Text = 16,
        Timestamp = 17,
        UniqueIdentifier = 18,
        Varbinary = 19,
        Varchar = 20,
        Xml = 21,
        Integer = 22,
        Smallint = 23,
        Date = 24
    }

    public enum FilterControlType
    {
        Select = 0,
        Text = 1,
        DropDown = 2,
        DatePicker = 3,
        CheckBox = 4
    }

    public enum ParameterType
    {
        UserAppliedFilter = 1,
        UserProfileFilter = 2
    }

    public enum ParameterFilterType
    {
        Equals = 1,
        NotEqual = 2,
        Contains = 3,
        StartWith = 4,
        EndWith = 5,
        GreaterThan = 6,
        GreaterThanOrEqualTo = 7,
        LessThan = 8,
        LessThanAndEqualTo = 9,
        Between = 10
    }

    public enum LinkActionType : byte
    {
        Report = 1,
        Forms = 4,
        CrystalReport = 3,
        BizweaverWebservice = 5,
        OtherURL = 2
    }

    public enum ActionMode
    {
        NewColumn = 2,
        ExistingColumn = 3
    }

    public enum ControlSectionType
    {
        HeaderLevel = 1,
        GridLevel = 2
    }

    public enum EventType
    {
        Select = 0,
        OnLostFocus = 1
    }

    public enum EventActionType
    {
        FormAction = 1,
        CustomAction = 2
    }

    public enum CustomWidgetType
    {
        Weather = 1,
        Joke = 2,
        Link = 3,
        Quote = 4

    }

    public enum MenuNodeType
    {
        Category=1,
        Object=2
    }

    public enum ReportDataSourceType
    {
        None = 0,
        B1Query = 1,
        StoredProcedure = 2,
        View = 3,
        CrystalReport = 4,
        QueryBuilder = 5,
        SqlQuery = 6

    }

    public enum FieldCategory
    {

        RegularField = 1,
        CalculatedField = 2,
        NonQueryField=3
    }

    public enum DropDownListValueType
    {
        None = 0,
        Dynamic = 1,
        Static = 2
    }

    public enum SortingOption
    {
        None = 0,
        Ascending = 1,
        Descending = 2
    }

    public enum ReportFormat
    {

        Regular = 0,
        Calendar = 1

    }

    public enum PaymentLogType
    {
        Select = 0,
        CreditCard = 1,
        ECheck = 2

    }
    public enum PaymentLogStatus
    {

        Success = 0,
        Failure = 1

    }

    

    public enum LandingPageType : short
    {

        Home = 0,
        Report = 1,
        Dashboard = 2,
        Form = 3

    }
    public enum ThumbnailImageType
    {

        None = 0,
        FortyFivePixel = 1,
        SixtyFivePixel = 2

    }

    public enum KPIObjectType
    {

        Report = 1,
        Chart = 3

    }

    public enum KeyMapped
    {

        None = 0,
        EnterKey = 1

    }
    public enum QueryCategory
    {

        Chart = -1,
        Grid = 9999

    }

    public enum ChartType
    {

        Pie = 1,
        Column = 2,
        Bar = 3,
        Line = 4,
        Area = 5,
        Bubble = 6,
        Doughnut = 8,
        Scatter = 9,
        Funnel = 11,
        Polar = 12,
        Radar = 13,
        ComboChart = 14,
    }

    public enum UserAcctRecoveryStatus
    {

        Initiated = 1,
        Set = 2

    }

    public enum FormatType
    {

        None = 0,
        Decimal = 1,
        Currency = 2,
        Date = 3,
        DateTime = 4,
        Email = 5,
        File = 6,
        Url = 7,
        Image = 8,
        TextMaximum = 9,
        Pixel45,
        Pixel65,
        Pixel250
    }

    public enum FavoriteStatus
    {

        Add = 1,
        Delete = 2

    }

    public enum FormItemType
    {

        Header = 1,
        Details = 2,
        Attachment=3

    }

    public enum FormSection
    {

        Header = 1,
        Details = 2,
        Footer=4,
        DataManipulationAction=5,
        DataFindAction=0

    }

    public enum ReportTypes
    {
        [EnumMember(Value =  "List + SubList")]
        ListSublist = 1,
        [EnumMember(Value =  "List")]
        List = 2,
        [EnumMember(Value =  "Calender")]
        Calender = 3,
        [EnumMember(Value =  "Multi Select")]
        MultiSelect = 4,
        [EnumMember(Value =  "Multi Select (Payment)")]
        MultiSelectPayment = 5,
        [EnumMember(Value =  "Crystal Report")]
        CrystalReport = 6
    }

    public enum FormLayoutType
    {
        [EnumMember(Value =  "Standard")]
        Standard = 1,
        [EnumMember(Value =  "Header-Detail")]
        HeaderDetail = 2,
       
    }

    public enum PaymentGateway
    {

        AuthorizeDotNet  = 1

    }

    public enum TableFieldType
    {
        [EnumMember(Value =  "nvarchar")]
        Nvarchar = 1,
        [EnumMember(Value =  "int")]
        Int = 2,
        [EnumMember(Value =  "integer")]
        Integer = 3,
        [EnumMember(Value =  "smallint")]
        SmallInt = 4,
        [EnumMember(Value =  "binary")]
        Binary = 5,
        [EnumMember(Value =  "boolean")]
        Boolean = 6,
        [EnumMember(Value =  "char")]
        Char = 7,
        [EnumMember(Value =  "datetime")]
        DateTime = 8,
        [EnumMember(Value =  "date")]
        Date =9,
        [EnumMember(Value =  "decimal")]
        Decimal = 10,
        [EnumMember(Value =  "float")]
        Float = 11,
        [EnumMember(Value =  "image")]
        Image = 12,
        [EnumMember(Value =  "money")]
        Money = 13,
        [EnumMember(Value =  "nchar")]
        NChar = 14,
        [EnumMember(Value =  "ntext")]
        NText = 15,
        [EnumMember(Value =  "numeric")]
        Numeric = 16,
        [EnumMember(Value =  "real")]
        Real = 17,
        [EnumMember(Value =  "sqlvariant")]
        SqlVariant = 18,
        [EnumMember(Value =  "text")]
        Text = 19,
        [EnumMember(Value =  "timestamp")]
        TimeStamp = 20,
        [EnumMember(Value =  "uniqueidentifier")]
        UniqueIdentifier = 21,
        [EnumMember(Value =  "varbinary")]
        VarBinary = 22,
        [EnumMember(Value =  "varchar")]
        VarChar = 23,
        [EnumMember(Value =  "xml")]
        Xml = 24,
        
    }

    public enum ApplicationOption
    {

        DataViewSettings = 1, 
        SystemSettings = 2,   
        EmailSettings = 3,
        ResetPasswordSettings = 4, 
        PaymentSettings = 5,
        FormSettings = 6, 
        SiteSettings = 7 ,
        SettingsDefaultValue=8,

    }


}
}
