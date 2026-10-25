export interface IEntradaAssistencia{
    id : number,
    pessoaFisicaId:number,
    nome:string,
    pessoaJuridicaId: number,
    entreguePorId: number,
    clienteAssociadoId: number,
    funcionarioId: number,
    funcionarioDesc: string,
    ns: string,
    numeroComprovanteCompra: string,
    codigoRastreio: string,
    comprovanteCompraId: number,
    numeroRemessa: string,
    numeroNF: string,
    numeroProtocoloTroca: string,
    trocaJaEfetuada: boolean,
    maquinaId: number,
    maquinaDesc: string,
    numeroSerie: string,
    entradaAssistenciaStatusId: number,
    dataEntrada: Date,
    acessorioList: [] ,
    EntradaAssistenciaDocumentoList: IEntradaAssistenciaDocument[]
}

export interface IEntradaAssistenciaListPage{
    id : number,    
    nome:string,
    maquinaDesc: string ,
    funcionarioDesc: string
}


export interface IEntradaAssistenciaDocument{
    id: number,
    EntradaAssistenciaTecnicaId : number,
    file: Int8Array [],
    fileName: string    
}
