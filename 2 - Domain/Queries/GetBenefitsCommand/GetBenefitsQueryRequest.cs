using MediatR;

public class GetBenefitsQueryRequest : IRequest<GetBenefitsQueryResponse>{
    public string CPF { get; set; }
}