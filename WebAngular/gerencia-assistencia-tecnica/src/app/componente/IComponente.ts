export {};

declare global {
  interface IComponente {
    id: number,
    nome: string,
    descricao: string,
    precoCompra: number,
    precoVenda: number,
    precoVendaAutorizada: number
  }
}