export class Tarefa {
    id: number
    titulo: string
    percentual: number
    prioridade: Prioridade
    dataCriacao: Date
    dataConclusao: Date

    constructor(id: number, titulo: string, percentual: number, dataCriacao: Date, dataConclusao: Date, prioridade: Prioridade) {
        this.id = id;
        this.titulo = titulo;
        this.percentual = percentual;
        this.dataCriacao = dataCriacao;
        this.dataConclusao = dataConclusao;
        this.prioridade = prioridade;
    }
}

export enum Prioridade {
    Baixa,
    Normal,
    Alta
}