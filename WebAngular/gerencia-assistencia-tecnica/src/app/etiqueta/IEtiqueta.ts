export {};

declare global {
  interface IEtiqueta {
    id: number,
    descricao: string,
    corId: number,
    corDes: string,
    colorHex: string
  }
}