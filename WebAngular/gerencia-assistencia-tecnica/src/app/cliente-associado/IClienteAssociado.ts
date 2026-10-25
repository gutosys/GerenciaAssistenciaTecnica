export {};

declare global {
  interface IClienteAssociado {
    id: number;
    nome: string;
    telefone: string;
    pessoaJuridicaId: number;
    pessoaJuridicaDes: string;
  }
}
 