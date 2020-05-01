namespace Enterprise.Service.Client.TransformationAspects
{
    internal interface ITransformationAspect<TDb, TDto>
        where TDb : class
        where TDto : class
    {
        TDb TransformToDatabaseModel(TDto dto);
        TDto TransformToDtoModel(TDb dbModel);
    }
}
