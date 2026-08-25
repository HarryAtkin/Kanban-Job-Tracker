namespace Api.Services.models.mappers
{
    public class ContributorMapper
    {
        public ContributorMapper() { }
        public Contributor ToContributor(ContributorInput input)
        {
            return new Contributor(null, input.BoardId, input.AccountId, input.PermissionType);
        }

        public ContributorOutput ToContributorOutput(Contributor input)
        {
            return new ContributorOutput((int)input.Id, input.BoardId, input.AccountId, input.PermissionType);
        }
    }
}
