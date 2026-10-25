export {};

declare global {
  interface IEstoque {
    id: number;
    quantidade: number;
    quantidadeMinima: number;
    componenteId: number;
    componenteDes: string;
  }
}