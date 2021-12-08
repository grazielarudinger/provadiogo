import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Venda } from "src/app/models/venda";
import { FormaService } from "src/app/services/forma.service";
import { ItemService } from "src/app/services/item.service";
import { VendaService } from "src/app/services/venda.service";
import { FormaPagamento } from "./../../../../models/forma";

@Component({
  selector: "app-finalizar",
  templateUrl: "./finalizar.component.html",
  styleUrls: ["./finalizar.component.css"],
})
export class FinalizarComponent implements OnInit {
  formas!: FormaPagamento[];
  formaId!: number;
  nome!: string;
  constructor(
    private router: Router,
    private formaService: FormaService,
    private itemService: ItemService,
    private vendaService: VendaService
  ) {}

  ngOnInit(): void {
    this.formaService.list().subscribe((formas) => {
      this.formas = formas;
    });
  }

  cadastrar(): void {
    let carrinhoId = localStorage.getItem("carrinhoId")! || "";
    this.itemService.getByCartId(carrinhoId).subscribe((itens) => {
      let venda: Venda = {
        cliente: this.nome,
        itens: itens,
        formaId: this.formaId,
        carrinhoId: localStorage.getItem("carrinhoId")!,
      };
      this.vendaService.create(venda).subscribe((venda) => {
        this.router.navigate(["produto/listar"]);
      });
    });
  }
}
