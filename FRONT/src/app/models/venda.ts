import { ItemVenda } from "./item-venda";
export interface Venda {
  id?: number;
  cliente: string;
  itens: ItemVenda[];
  formaId: number;
  criadoem?: string;
  carrinhoId: string;
}
