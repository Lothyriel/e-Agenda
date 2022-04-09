import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Prioridade, Tarefa } from 'src/app/shared/model/Tarefa';
import { TarefaService } from '../services/tarefaServices';

@Component({
  selector: 'app-tarefa-editar',
  templateUrl: './tarefa-editar.component.html',
})
export class TarefaEditarComponent implements OnInit {

  titulo: string = "Editar Tarefa"
  cadastroForm: FormGroup;
  tarefa: Tarefa;
  
  prioridade = Prioridade;
  prioridades: any[];
  id: any;

  constructor(private _Activatedroute: ActivatedRoute, private servicos: TarefaService) { }

  ngOnInit(): void {
    this.prioridades = Object.keys(Prioridade).filter(p=> !isNaN(Number(p)))

    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.tarefa = this.servicos.obterTarefa(this.id)

    this.cadastroForm = new FormGroup({
      titulo: new FormControl(this.tarefa.titulo),
      percentual: new FormControl(this.tarefa.percentual),
      prioridade: new FormControl(this.tarefa.prioridade),
      dataCriacao: new FormControl(this.tarefa.dataCriacao.toISOString().substring(0, 10)),
      dataConclusao: new FormControl(this.tarefa.dataConclusao.toISOString().substring(0, 10)),
    })
  }
  editarTarefa() {
    this.tarefa = Object.assign({}, this.tarefa, this.cadastroForm.value);
    this.servicos.atualizarTarefa(this.tarefa);
  }
}
