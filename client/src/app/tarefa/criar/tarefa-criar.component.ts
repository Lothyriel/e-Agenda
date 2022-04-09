import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Prioridade, Tarefa } from 'src/app/shared/model/Tarefa';
import { TarefaService } from '../services/tarefaServices';

@Component({
  selector: 'app-tarefa-criar',
  templateUrl: './tarefa-criar.component.html',
})
export class TarefaCriarComponent implements OnInit {

  titulo: string = "Cadastrar Tarefa"
  cadastroForm: FormGroup

  prioridade = Prioridade;
  prioridades: any[];
  tarefa: Tarefa;

  constructor(private servico: TarefaService) { }

  ngOnInit(): void {
    this.prioridades = Object.keys(Prioridade).filter(p=> !isNaN(Number(p)))

    this.cadastroForm = new FormGroup({
      titulo: new FormControl(''),
      prioridade: new FormControl(''),
      dataCriacao: new FormControl(''),
      percentual: new FormControl(''),
      dataConclusao: new FormControl('')
    })
  }

  add(): void {
    this.tarefa = Object.assign({}, this.tarefa, this.cadastroForm.value)
    this.servico.adicionarTarefa(this.tarefa)
    this.cadastroForm.reset()
  }
}
