import { Component, OnInit } from '@angular/core';
import { Tarefa } from 'src/app/shared/model/Tarefa';
import { TarefaService } from '../services/tarefaServices';

@Component({
  selector: 'app-tarefa-listar',
  templateUrl: './tarefa-listar.component.html',
})
export class TarefaListarComponent implements OnInit {

  titulo: string = "Lista Tarefas";
  listaTarefas: Tarefa[] = [];
  constructor(private servico: TarefaService) { }

  ngOnInit(): void {
    this.obterTarefas();
  }

  obterTarefas(): void {
    this.listaTarefas = this.servico.obterTarefas()
  }
}
