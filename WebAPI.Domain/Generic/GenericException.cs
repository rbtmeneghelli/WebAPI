namespace WebAPI.Domain.Generic;

public abstract class GenericException : Exception
{
    public GenericException(string message) : base(message)
    {

    }

    private void ShowException(string fixMessage, string newMessage)
    {
        throw new Exception(GuardClauses.IsNullOrWhiteSpace(newMessage) == true ? fixMessage : newMessage, InnerException);
    }

    public virtual void ShowDefaultExceptionMessage(string message = "")
    {
        ShowException(string.Empty, message);
    }

    public virtual void ShowAddExceptionMessage(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_ADD, message);
    }

    public virtual void ShowUpdateException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_UPDATE, message);
    }

    public virtual void ShowDeleteLogicException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_DELETELOGIC, message);
    }

    public virtual void ShowDeletePhysicalException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_DELETEPHYSICAL, message);
    }

    public virtual void ShowResearchException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_RESEARCH, message);
    }

    public virtual void ShowGetAllException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_GETALL, message);
    }

    public virtual void ShowGetIdException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_GETID, message);
    }

    public virtual void ShowGetDdlException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_GETDDL, message);
    }

    public virtual void ShowLoginException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_LOGIN, message);
    }

    public virtual void ShowChangePasswordException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_CHANGEPASSWORD, message);
    }

    public virtual void ShowResetPasswordException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_RESETPASSWORD, message);
    }

    public virtual void ShowActiveRecordException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_ACTIVERECORD, message);
    }

    public virtual void ShowBackupException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_BACKUP, message);
    }

    public virtual void ShowProcedureException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_PROCEDURE, message);
    }

    public virtual void ShowAddCityException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_ADDCITY, message);
    }

    public virtual void ShowRefreshTokenException(string message = "")
    {
        ShowException(FixConstants.ERROR_IN_REFRESHTOKEN, message);
    }

    public virtual void ShowExcelException(string message = "")
    {
        ShowException(FixConstants.EXCEPTION_EXCEL, message);
    }
}