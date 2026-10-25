export {};

declare global {
  interface ICidade {
    id: number;
    descricao: string;
    estadoId: number;
  }
}